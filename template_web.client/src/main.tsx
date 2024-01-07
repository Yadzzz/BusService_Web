import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./assets/css/main.css";
import { CurrentUserProvider } from "./Infrastructure/Domain/CurrentUserContext";
import ApiClient from "./Infrastructure/API/apiClient";

const Root = () => {
  const [isBackendReady, setIsBackendReady] = useState(false);

  useEffect(() => {
    if (process.env.NODE_ENV === "development") {
      const api = new ApiClient();

      // Function to check backend status
      const checkBackendStatus = async () => {
        try {
          await api.get("/api/ping");
          setIsBackendReady(true);
        } catch (error) {
          console.error("Error checking backend status:", error);
          setIsBackendReady(false);
        }
      };

      // Initial check
      checkBackendStatus();

      // Set up an interval to check the backend status periodically
      const intervalId = setInterval(checkBackendStatus, 1000); // Adjust the interval as needed

      // Cleanup the interval on component unmount
      return () => clearInterval(intervalId);
    } else {
      setIsBackendReady(true);
    }
  }, []);

  return (
    <>
      {isBackendReady ? (
        <React.StrictMode>
          <CurrentUserProvider>
            <App />
          </CurrentUserProvider>
        </React.StrictMode>
      ) : (
        <div>Loading...</div>
      )}
    </>
  );
};

ReactDOM.createRoot(document.getElementById("root")!).render(<Root />);