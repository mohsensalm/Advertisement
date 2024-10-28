import axios from 'axios';
import { authService } from './authService';

const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
    headers: {
        'Content-Type': 'application/json'
    }
});

// Add auth token to requests
api.interceptors.request.use(
    config => {
        const token = authService.getToken();
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    error => {
        return Promise.reject(error);
    }
);

// Handle 401 responses
api.interceptors.response.use(
    response => response,
    error => {
        if (error.response?.status === 401) {
            authService.logout();
            window.location.href = '/login';
        }
        return Promise.reject(error);
    }
);

export default api;