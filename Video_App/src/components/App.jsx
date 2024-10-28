import React from 'react';
import { AuthProvider } from './context/AuthContext';
import AuthServiceUI from './components/auth/AuthServiceUI';
import { BrowserRouter } from 'react-router-dom';

function App() {
    return (
        <BrowserRouter>
            <AuthProvider>
                <div className="min-h-screen bg-gray-50">
                    <AuthServiceUI />
                </div>
            </AuthProvider>
        </BrowserRouter>
    );
}

export default App;