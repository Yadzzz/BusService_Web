import { useEffect } from "react";
import ApiClient from "../Infrastructure/API/apiClient";
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const navigate = useNavigate();

  const redirectToLogin = () => {
    navigate('/login'); // Redirect to the home page
  };

  useEffect(() => {
    try {
    const api = new ApiClient();
    api.get<{ message: string }>(`/api/Authentication/logout`)
      .then((response) => {
        console.log(response);
        redirectToLogin();
      })
      .catch((error) => {
        console.error("Check authentication error:", error);
      });
    } catch (error) {
      console.log("Check authentication error:", error);
    }
  }, []);
  return (
    <>
    </>
  );
}

export default Login;
