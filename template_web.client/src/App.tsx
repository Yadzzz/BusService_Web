/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { Suspense, useEffect, useState, useContext } from "react";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import Home from "./Pages/Home";
import JQueryComponents from "./Components/Shared/JQueryComponents";
import Login from "./Pages/Login";
import ApiClient from "./Infrastructure/API/apiClient";
import Logout from "./Pages/Logout";
import AuthService from "./Services/authService";
import { CurrentUserProvider } from "./Infrastructure/Domain/CurrentUserContext";
import { useCurrentUser } from "./Infrastructure/Domain/CurrentUserContext";
import Header from "./Components/Shared/Header";
import Features from "./Pages/Features";
import Pricing from "./Pages/Pricing";
import Contact from "./Pages/Contact";
import Loader from "./Components/Shared/Loader";

import ClientHome from "./Pages/Client/Home";
import Buses from "./Pages/Client/Buses";

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean | null>(null);
  const [tokenValidationAttempted, setTokenValidationAttempted] =
    useState(false);
  const { user, setUser } = useCurrentUser();

  useEffect(() => {
    checkAuthentication();
  }, []);


  const checkAuthentication = async () => {
    try {
      const user = await AuthService(setIsAuthenticated);

      if (user) {
        setUser(user);

        // Use the callback version of setIsAuthenticated to avoid the loop
        setIsAuthenticated((currentState) => {
          if (currentState !== true) {
            return true;
          }
          return currentState;
        });
      } else {
        setIsAuthenticated(false);
      }
    } catch (error) {
      console.error("Check authentication error:", error);
      setIsAuthenticated(false);
    } finally {
      setTokenValidationAttempted(true);
    }
  };

  function ProtectedRoute({ element }: { element: React.ReactNode }) {
    if (isAuthenticated === null) {
      return <Loader />; // Show loader while checking authentication
    }

    if (isAuthenticated) {
      return element;
    } else {
      return <Navigate to="/login" />;
    }
  }

  /*if (isAuthenticated === null) {
    return <div className="container">Loading...</div>;
  }*/

  return (
    <Router>
      <Suspense fallback={<Loader />}>
        <div className="bg-white">
          <Routes>
            {/*Public Routes*/}
            <Route path="/" element={<Home />} />
            <Route path="/features" element={<Features />} />
            <Route path="/pricing" element={<Pricing />} />
            <Route path="/contact" element={<Contact />} />

            {/*Client Routes*/}
            <Route
              path="/client/dashboard"
              element={<ProtectedRoute element={<ClientHome />} />}
            />
            <Route
              path="/client/buses"
              element={<ProtectedRoute element={<Buses />} />}
            />

            {/*Authentication Routes*/}
            <Route
              path="/login"
              element={<Login setIsAuthenticated={setIsAuthenticated} />}
            />
            <Route path="/logout" element={<Logout />} />

            {/*Catch-all route*/}
            <Route path="*" element={<Navigate to="/" />} />
          </Routes>
        </div>
        <JQueryComponents />
      </Suspense>
    </Router>
  );
}

export default App;
