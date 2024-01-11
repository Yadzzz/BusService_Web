/* eslint-disable @typescript-eslint/no-unused-vars */
// authService.js
import ApiClient from '../Infrastructure/API/apiClient';
import React from 'react';
import { useCurrentUser } from "../Infrastructure/Domain/CurrentUserContext";
import UsersHandler from "../Infrastructure/Domain/UsersHandler";
import User from '../Models/User';


const AuthService = async (setIsAuthenticated: React.Dispatch<React.SetStateAction<boolean | null>>): Promise<User | null> => {
    try {
        const apiClient = new ApiClient();

        return apiClient.get("/api/Authentication/validatetoken")
            .then(async (response) => {
                const usersHandler = new UsersHandler();
                const user = await usersHandler.getUserData();

                console.log('user', user);
                                
                if (user) {
                    return user;
                } else {
                    return null;
                }
            })
            .catch((error) => {
                setIsAuthenticated(false);
                return null;
            })
            .finally(() => {
                // You can add any post-fetch logic here
            });
    } catch (error) {
        //console.error("Authentication error:", error);
        setIsAuthenticated(false);
        return null;
    }
};


export default AuthService;
