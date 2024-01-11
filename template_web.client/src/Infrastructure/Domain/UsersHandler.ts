/* eslint-disable @typescript-eslint/no-unused-vars */
import UsersApi from "../API/UsersApi";
import User from "../../Models/User";
import { useCurrentUser } from "../Domain/CurrentUserContext";

class UsersHandler {
  private usersApi: UsersApi;

  constructor() {
    this.usersApi = new UsersApi();
  }

  public async getUserData(): Promise<User> {
    try {
      const user: User = await this.usersApi.getUserData();
      if(!user) {
        throw new Error('User data not found');
      }
      
      return user;
    } catch (error) {
      console.error("Error getting user data:", error);
      throw error;
    }
  }
}

export default UsersHandler;