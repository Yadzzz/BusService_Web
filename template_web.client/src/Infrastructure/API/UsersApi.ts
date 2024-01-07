import ApiClient from "./apiClient";
import User from "../../Models/User";

class UsersApi {
    private api: ApiClient;
  
    constructor() {
      this.api = new ApiClient();
    }
  
    public async getUserData(): Promise<User> {
      //const response = await this.api.get('api/Users/UserContext');
      //return response.data;

      try {
        const response = await this.api.get<User>('api/Users/UserContext');
        const user: User = response;
        return user;
      } catch (error) {
        console.error("Error fetching user data:", error);
        throw error;
      }
    }
  }
  
  export default UsersApi;