import {create} from 'axios'

const api = create({
    baseURl: 'http://jsonplaceholder.typicode.com/'
});

export default api;