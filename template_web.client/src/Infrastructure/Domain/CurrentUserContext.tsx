import React, { createContext, useContext, ReactNode } from 'react';
import User from '../../Models/User';

interface CurrentUserContextProps {
  children: ReactNode;
}

interface CurrentUserContextValue {
  user: User | null;
  setUser: (user: User) => void;
  clearUser: () => void;
}

const CurrentUserContext = createContext<CurrentUserContextValue | undefined>(undefined);

const CurrentUserProvider: React.FC<CurrentUserContextProps> = ({ children }) => {
  const [user, setUser] = React.useState<User | null>(null);

  const clearUser = () => {
    setUser(null);
  };

  return (
    <CurrentUserContext.Provider value={{ user, setUser, clearUser }}>
      {children}
    </CurrentUserContext.Provider>
  );
};

const useCurrentUser = () => {
  const context = useContext(CurrentUserContext);

  if (!context) {
    throw new Error('useCurrentUser must be used within a CurrentUserProvider');
  }

  return context;
};

export { CurrentUserProvider, useCurrentUser };
