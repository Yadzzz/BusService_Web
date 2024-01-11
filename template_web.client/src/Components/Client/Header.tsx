/* eslint-disable @typescript-eslint/no-unused-vars */
import { useState } from "react";
import logo from "../../assets/icon.png";
import profileIcon from "../../assets/profile.png";

interface headerProps {
  currentPage: string;
}

const Header = (props: headerProps) => {
  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);
  const [isProfileDropdownOpen, setIsProfileDropdownOpen] = useState(false);

  return (
    <nav className="bg-gray-800">
      <div className="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
        <div className="relative flex h-16 items-center justify-between">
          {/* Mobile menu button */}
          <div className="absolute inset-y-0 left-0 flex items-center sm:hidden">
            <button
              type="button"
              className="inline-flex items-center justify-center p-2 rounded-md text-gray-400 hover:text-white hover:bg-gray-700 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white"
              aria-controls="mobile-menu"
              aria-expanded="false"
              onClick={() => setIsMobileMenuOpen(!isMobileMenuOpen)}
            >
              <span className="sr-only">Open main menu</span>
              {/* Icon for menu open/close */}
              <svg
                className={`${isMobileMenuOpen ? "hidden" : "block"} h-6 w-6`}
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  d="M4 6h16M4 12h16m-7 6h7"
                />
              </svg>
              <svg
                className={`${isMobileMenuOpen ? "block" : "hidden"} h-6 w-6`}
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  d="M6 18L18 6M6 6l12 12"
                />
              </svg>
            </button>
          </div>

          {/* Logo and Navigation Menu */}
          <div className="flex-1 flex items-center justify-center sm:items-stretch sm:justify-start">
            <div className="flex-shrink-0 flex items-center">
              <img className="h-8 w-auto" src={logo} alt="Your Company" />
            </div>
            <div className="hidden sm:block sm:ml-6">
              <div className="flex space-x-4">
                {/* Navigation Links */}
                {/*<a href="/" className="bg-gray-900 text-white px-3 py-2 rounded-md text-sm font-medium">Dashboard</a>*/}
                <a
                  href="/client/dashboard"
                  className={`${
                    props.currentPage === "dashboard"
                      ? "bg-gray-900 text-white"
                      : "text-gray-200 hover:bg-gray-700 hover:text-white"
                  } px-3 py-2 rounded-md text-sm font-medium`}
                >
                  Dashboard
                </a>
                <a
                  href="/client/buses"
                  className={`${
                    props.currentPage === "busservices"
                      ? "bg-gray-900 text-white"
                      : "text-gray-200 hover:bg-gray-700 hover:text-white"
                  } px-3 py-2 rounded-md text-sm font-medium`}
                >
                  Bus Services
                </a>
                <a
                  href="/client/access"
                  className={`${
                    props.currentPage === "access"
                      ? "bg-gray-900 text-white"
                      : "text-gray-200 hover:bg-gray-700 hover:text-white"
                  } px-3 py-2 rounded-md text-sm font-medium`}
                >
                  Access
                </a>
              </div>
            </div>
          </div>

          {/* Right-aligned items */}
          <div className="absolute inset-y-0 right-0 flex items-center pr-2 sm:static sm:inset-auto sm:ml-6 sm:pr-0" style={{ zIndex: 9999 }}>
            {/* Profile dropdown */}
            <div className="relative ml-3">
              <div>
                <button
                  type="button"
                  className="flex rounded-full bg-gray-800 text-sm focus:outline-none focus:ring-2 focus:ring-white focus:ring-offset-2 focus:ring-offset-gray-800"
                  id="user-menu-button"
                  aria-haspopup="true"
                  onClick={() =>
                    setIsProfileDropdownOpen(!isProfileDropdownOpen)
                  }
                >
                  <span className="sr-only">Open user menu</span>
                  <img
                    className="h-8 w-8 rounded-full"
                    src={profileIcon}
                    alt="User profile"
                  />
                </button>
              </div>
              {/* Dropdown menu */}
              <div
                className={`${
                  isProfileDropdownOpen ? "block" : "hidden"
                } absolute right-0 mt-2 w-48 origin-top-right rounded-md bg-white py-1 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none`}
                role="menu"
                aria-orientation="vertical"
                aria-labelledby="user-menu-button"
              >
                <a
                  href="#"
                  className="block px-4 py-2 text-sm text-gray-700"
                  role="menuitem"
                >
                  Your Profile
                </a>
                <a
                  href="#"
                  className="block px-4 py-2 text-sm text-gray-700"
                  role="menuitem"
                >
                  Settings
                </a>
                <a
                  href="/logout"
                  className="block px-4 py-2 text-sm text-gray-700"
                  role="menuitem"
                >
                  Sign out
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>

      {/* Mobile Menu */}
      <div
        className={`${isMobileMenuOpen ? "block" : "hidden"} sm:hidden`}
        id="mobile-menu"
      >
        <div className="px-2 pt-2 pb-3 space-y-1">
          {/* Mobile Navigation Links */}
          <a
            href="/"
            className={`${
              props.currentPage === "dashboard"
                ? "bg-gray-900 text-white"
                : "text-gray-200 hover:bg-gray-700 hover:text-white"
            } block px-3 py-2 rounded-md text-base font-medium`}
          >
            Dashboard
          </a>
          <a
            href="/client/buses"
            className={`${
              props.currentPage === "busservices"
                ? "bg-gray-900 text-white"
                : "text-gray-200 hover:bg-gray-700 hover:text-white"
            } block px-3 py-2 rounded-md text-base font-medium`}
          >
            Bus Services
          </a>
          <a
            href="/client/access"
            className={`${
              props.currentPage === "access"
                ? "bg-gray-900 text-white"
                : "text-gray-200 hover:bg-gray-700 hover:text-white"
            } block px-3 py-2 rounded-md text-base font-medium`}
          >
            Access
          </a>
        </div>
      </div>
    </nav>
  );
};
export default Header;
