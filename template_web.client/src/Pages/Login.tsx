/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { useState, useEffect } from "react";
import ApiClient from "../Infrastructure/API/apiClient";
import { useNavigate } from "react-router-dom";
import AuthService from "../Services/authService";
import UsersHandler from "../Infrastructure/Domain/UsersHandler";
import { useCurrentUser } from "../Infrastructure/Domain/CurrentUserContext";
import { PhotoIcon, UserCircleIcon } from '@heroicons/react/24/solid'

interface LoginProps {
  setIsAuthenticated: (isAuthenticated: boolean) => void;
}

const Login: React.FC<LoginProps> = ({ setIsAuthenticated }: LoginProps) => {
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [errors, setErrors] = useState({ username: "", password: "" });
  const { user, setUser } = useCurrentUser();

  const redirectToHome = () => {
    navigate("/"); // Redirect to the home page
  };

  useEffect(() => {
    const api = new ApiClient();
    try {
      api
        .get<{ message: string }>(`/api/Authentication/validatetoken`)
        .then((response) => {
          setIsAuthenticated(true);
          redirectToHome(); // Redirect to the home page if the user is already authenticated
        })
        .catch((error) => {
          console.error("authentication check error:", error);
        });
    } catch (error) {
      console.log("Authentication check error:", error);
    }

    //AuthService(setIsAuthenticated);
  }, []);

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    if (name === "username") {
      setUsername(value);
      setErrors({ ...errors, username: "" }); // Clear the username error when typing
    } else if (name === "password") {
      setPassword(value);
      setErrors({ ...errors, password: "" }); // Clear the password error when typing
    }
  };

  const validateForm = () => {
    const newErrors = { username: "", password: "" };
    let isValid = true;

    if (!username) {
      newErrors.username = "Username is required";
      isValid = false;
    }

    if (!password) {
      newErrors.password = "Password is required";
      isValid = false;
    }

    setErrors(newErrors);
    return isValid;
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    if (validateForm()) {
      console.log("Form is valid");
      // Make the API request for authentication or perform other actions
      const api = new ApiClient();
      api
        .post<{ token: string }>("/api/Authentication/authenticate", {
          username,
          password,
        })
        .then(async (response) => {
          const usersHandler = new UsersHandler();
          const user = await usersHandler.getUserData();
          console.log("User data:", user);

          if (user) {
            const usersHandler = new UsersHandler();
            const user = await usersHandler.getUserData();
            setUser(user);
            setIsAuthenticated(true);
            redirectToHome();
          } else {
            setIsAuthenticated(false);
          }
        })
        .catch((error) => {
          console.error("Login error:", error);
        });
    } else {
      console.log("Form is not valid");
    }
  };

  // Rest of the component code...

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Username</label>
        <input
          type="text"
          name="username"
          placeholder="Enter your username"
          value={username}
          onChange={handleInputChange}
        />
        <span className="error">{errors.username}</span>
      </div>
      <br />
      <div>
        <label>Password</label>
        <input
          type="password"
          name="password"
          placeholder="Enter your password"
          value={password}
          onChange={handleInputChange}
        />
        <span className="error">{errors.password}</span>
      </div>

      <button type="submit">Login</button>
    </form>
  );
};

export default Login;