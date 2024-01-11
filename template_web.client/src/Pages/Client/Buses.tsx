/* eslint-disable @typescript-eslint/no-unused-vars */
import React, { useEffect, useState } from "react";
import Header from "../../Components/Client/Header";
import Loader from "../../Components/Shared/Loader";
import ApiClient from "../../Infrastructure/API/apiClient";

interface BusService {
  id: number;
  identifier: string;
  name: string;
}

const Buses = () => {
  const [customers, setCustomers] = useState<BusService[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchCustomers = async () => {
      const api = new ApiClient();
      const response = await api
        .get("api/busservices")
        .then((response: BusService[]) => {
          setCustomers(response);
        })
        .catch((error) => {
          console.error("Error fetching data:", error);
          setCustomers([]);
        })
        .finally(() => {
          setIsLoading(false);
        });
    };
    fetchCustomers();
    setIsLoading(false);
  }, []);

  return (
    <>
      {isLoading && <Loader />}

      <Header currentPage="customers" />

      <div className="relative isolate px-6 pt-0 lg:px-8">
        {/*<div className="mx-auto max-w-6xl py-32 sm:py-48 lg:py-56">*/}
        <div className="mx-auto max-w-6xl py-2 sm:py-12 lg:py-20">
          <div className="overflow-x-auto relative shadow-md sm:rounded-lg">
            <div className="p-6 bg-white shadow-md rounded-lg">
              <div className="overflow-x-auto shadow-md sm:rounded-lg mb-5">
                <h2 className="text-xl font-semibold mb-4 text-center mb-10">
                  Bus Services
                </h2>
                <table className="w-full text-sm text-left text-gray-500">
                  <thead className="text-xs text-gray-700 uppercase bg-gray-50">
                    <tr>
                      <th scope="col" className="px-6 py-3">
                        Id
                      </th>
                      <th scope="col" className="px-6 py-3">
                        Identifier
                      </th>
                      <th scope="col" className="px-6 py-3">
                        Name
                      </th>
                      <th scope="col" className="px-6 py-3">
                        Visa
                      </th>
                    </tr>
                  </thead>
                  <tbody>
                    {customers.map((customer) => (
                      <tr
                        key={customer.id}
                        className="bg-white border-b hover:bg-gray-100"
                      >
                        <td className="px-6 py-4">{customer.id}</td>
                        <td className="px-6 py-4">{customer.identifier}</td>
                        <td className="px-6 py-4">{customer.name}</td>
                        <td className="px-6 py-4">
                          <button className="bg-gray-600 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded transition duration-300 ease-in-out">
                            Visa
                          </button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
              <p className="text-center text-gray-400 mt-4"></p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};
export default Buses;
