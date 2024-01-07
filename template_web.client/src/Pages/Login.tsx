/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { useState, useEffect } from "react";
import ApiClient from "../Infrastructure/API/apiClient";
import { useNavigate } from "react-router-dom";
import AuthService from "../Services/authService";
import UsersHandler from "../Infrastructure/Domain/UsersHandler";
import { useCurrentUser } from "../Infrastructure/Domain/CurrentUserContext";
import { PhotoIcon, UserCircleIcon } from "@heroicons/react/24/solid";

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
    <>
      {/*<form onSubmit={handleSubmit}>
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
  </form>*/}

      <div className="relative isolate px-6 pt-1 lg:px-8">
        <div
          className="absolute inset-x-0 -top-40 -z-10 transform-gpu overflow-hidden blur-3xl sm:-top-80"
          aria-hidden="true"
        >
          <div
            className="relative left-[calc(50%-11rem)] aspect-[1155/678] w-[36.125rem] -translate-x-1/2 rotate-[30deg] bg-gradient-to-tr from-[#ff80b5] to-[#9089fc] opacity-30 sm:left-[calc(50%-30rem)] sm:w-[72.1875rem]"
            style={{
              clipPath:
                "polygon(74.1% 44.1%, 100% 61.6%, 97.5% 26.9%, 85.5% 0.1%, 80.7% 2%, 72.5% 32.5%, 60.2% 62.4%, 52.4% 68.1%, 47.5% 58.3%, 45.2% 34.5%, 27.5% 76.7%, 0.1% 64.9%, 17.9% 100%, 27.6% 76.8%, 76.1% 97.7%, 74.1% 44.1%)",
            }}
          />
        </div>

        <div className="mx-auto max-w-2xl py-32 sm:py-48 lg:py-56">
          {/* Login Form */}
          <div className="bg-white p-8 rounded-lg shadow-md">
            <h2 className="text-3xl font-bold text-center text-gray-900">
              Sign In
            </h2>
            <form className="mt-8">
              <div className="mb-4">
                <label
                  htmlFor="email"
                  className="block text-sm font-medium text-gray-700"
                >
                  Email
                </label>
                <input
                  type="email"
                  id="email"
                  className="mt-1 block w-full px-3 py-2 border rounded-md shadow-sm focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                  placeholder="you@example.com"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                />
              </div>
              <div className="mb-6">
                <label
                  htmlFor="password"
                  className="block text-sm font-medium text-gray-700"
                >
                  Password
                </label>
                <input
                  type="password"
                  id="password"
                  className="mt-1 block w-full px-3 py-2 border rounded-md shadow-sm focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                  placeholder="••••••••"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>
              <div className="flex items-center justify-between">
                <button
                  type="submit"
                  className="w-full bg-indigo-600 hover:bg-indigo-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                  onClick={() => handleSubmit}
                >
                  Sign In
                </button>
              </div>
            </form>
            <p className="mt-4 text-center text-sm text-gray-600">
              Don't have an account?{" "}
              <a
                href="#"
                className="font-medium text-indigo-600 hover:text-indigo-500"
              >
                Sign Up
              </a>
            </p>
          </div>
        </div>

        <div
          className="absolute inset-x-0 top-[calc(100%-13rem)] -z-10 transform-gpu overflow-hidden blur-3xl sm:top-[calc(100%-30rem)]"
          aria-hidden="true"
        >
          <div
            className="relative left-[calc(50%+3rem)] aspect-[1155/678] w-[36.125rem] -translate-x-1/2 bg-gradient-to-tr from-[#ff80b5] to-[#9089fc] opacity-30 sm:left-[calc(50%+36rem)] sm:w-[72.1875rem]"
            style={{
              clipPath:
                "polygon(74.1% 44.1%, 100% 61.6%, 97.5% 26.9%, 85.5% 0.1%, 80.7% 2%, 72.5% 32.5%, 60.2% 62.4%, 52.4% 68.1%, 47.5% 58.3%, 45.2% 34.5%, 27.5% 76.7%, 0.1% 64.9%, 17.9% 100%, 27.6% 76.8%, 76.1% 97.7%, 74.1% 44.1%)",
            }}
          />
        </div>
      </div>
    </>
  );
};

export default Login;
