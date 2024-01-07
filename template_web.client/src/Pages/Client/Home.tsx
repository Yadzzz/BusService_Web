import { useEffect, useState } from "react";
import ReactIntro from "../../Components/Shared/ReactIntro";
import ApiClient from "../../Infrastructure/API/apiClient";
import { useCurrentUser } from "../../Infrastructure/Domain/CurrentUserContext";

const Home = () => {
  const { user } = useCurrentUser();
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    let isMounted = true;

    const fetchData = async () => {
      try {
        const api = new ApiClient();
        const response = await api.get("api/Users/UserContext");

        if (isMounted) {
          console.log(response);
          setLoading(false);
        }
      } catch (error) {
        console.error("Error fetching data:", error);
        setLoading(false);
      }
    };

    fetchData();

    return () => {
      // Cleanup function to handle component unmounting
      isMounted = false;
    };
  }, [user]);  // Include user in the dependency array if you want the effect to run when user changes

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <>
      <ReactIntro />
    </>
  );
};

export default Home;
