/* eslint-disable @typescript-eslint/no-explicit-any */
import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from 'axios';
import { getAuthorizationCookieValue } from '../Security/cookieHandler';

class ApiClient {
  private axiosInstance: AxiosInstance;

  constructor() {
    this.axiosInstance = axios.create({
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + getAuthorizationCookieValue(),
      },
    });
  }

  public async get<T>(path: string, config?: AxiosRequestConfig): Promise<T> {
    const response: AxiosResponse<T> = await this.axiosInstance.get(path, config);
    return response.data;
  }

  public async post<T>(path: string, data?: any, config?: AxiosRequestConfig): Promise<T> {
    const response: AxiosResponse<T> = await this.axiosInstance.post(path, data, config);
    return response.data;
  }

  // You can add other HTTP methods (PUT, DELETE, etc.) as needed.

  // You may also add error handling and authentication logic here if necessary.
}

export default ApiClient;
