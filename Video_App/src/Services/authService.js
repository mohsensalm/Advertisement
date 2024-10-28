import api from './api';

const TOKEN_KEY = 'jwt_token';

export const authService = {
    login: async (credentials) => {
        const response = await api.post('/api/auth/login', credentials);
        const { token } = response.data;
        localStorage.setItem(TOKEN_KEY, token);
        api.defaults.headers.common['Authorization'] = `Bearer ${token}`;
        return response.data;
    },

    logout: () => {
        localStorage.removeItem(TOKEN_KEY);
        delete api.defaults.headers.common['Authorization'];
    },

    getToken: () => {
        return localStorage.getItem(TOKEN_KEY);
    },

    isAuthenticated: () => {
        const token = localStorage.getItem(TOKEN_KEY);
        return !!token; // Returns true if token exists
    },

    register: async (userData) => {
        const response = await api.post('/api/auth/register', userData);
        return response.data;
    }
};