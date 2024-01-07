/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { Suspense, useEffect, useState, useContext } from "react";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import "./App.css";
import Home from "./Pages/Home";
import JQueryComponents from "./Components/Shared/JQueryComponents";
import Login from "./Pages/Login";
import ApiClient from "./Infrastructure/API/apiClient";
import Logout from "./Pages/Logout";
import AuthService from "./Services/authService";
import { CurrentUserProvider } from "./Infrastructure/Domain/CurrentUserContext";
import { useCurrentUser } from "./Infrastructure/Domain/CurrentUserContext";
interface Forecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean | null>(null);
  const [tokenValidationAttempted, setTokenValidationAttempted] =
    useState(false);
  const { user, setUser } = useCurrentUser();

  useEffect(() => {
    const checkAuthentication = async () => {
      try {
        const user = await AuthService(setIsAuthenticated);

        if (user) {
          console.log(user);
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

    if (!tokenValidationAttempted) {
      checkAuthentication();
    }
  }, [tokenValidationAttempted]); // Use tokenValidationAttempted as a dependency

  function ProtectedRoute({ element }: { element: React.ReactNode }) {
    if (isAuthenticated) {
      return element;
    } else {
      return <Navigate to="/login" />; // Redirect to the login page
    }
  }

  if (isAuthenticated === null) {
    return <div className="container">Loading...</div>;
  }

  return (
    <Router>
      <Suspense fallback={<div className="container">Loading...</div>}>
        <Routes>
          <Route path="/" element={<ProtectedRoute element={<Home />} />} />
          <Route
            path="/login"
            element={<Login setIsAuthenticated={setIsAuthenticated} />}
          />
          <Route path="/logout" element={<Logout />} />
          <Route path="*" element={<Navigate to="/" />} />
        </Routes>
        <JQueryComponents />
      </Suspense>
    </Router>
  );
}

export default App;
