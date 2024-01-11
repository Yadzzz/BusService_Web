/* eslint-disable @typescript-eslint/no-unused-vars */
import { useEffect, useState } from "react";
import ApiClient from "../../Infrastructure/API/apiClient";
import { useCurrentUser } from "../../Infrastructure/Domain/CurrentUserContext";
import Header from "../../Components/Client/Header";
import Loader from "../../Components/Shared/Loader";

const Home = () => {
  const { user } = useCurrentUser();
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    setLoading(false);
  }, []);

  if (loading) {
    return <Loader />;
  }

  return (
    <>
      <Header currentPage="Dashboard" />
    </>
  );
};

export default Home;
