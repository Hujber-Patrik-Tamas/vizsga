import Axios from 'axios';
Axios.defaults.baseURL = 'https://caroftheyear2023.jedlik.cloud';

export default {
    getGyartok(){
        return Axios.get('/api/manufacturers')
    },
    getAutok(){
        return Axios.get('/api/cars')
    },
    getGyartoAutoi(manufacturerid){
        return Axios.get(`/api/cars/${manufacturerid}`)
    },
    postVote(vote){
        console.log(vote);
        return Axios.post('/api/vote',vote);
    },
    getUserById(id){
        return Axios.get(`/users/${id}`)
    },
    saveUser(user){
        return Axios.post('/users',user);
    },
    updateUser(user,id){
        return Axios.put(`/users/${id}`,user);
    }
}