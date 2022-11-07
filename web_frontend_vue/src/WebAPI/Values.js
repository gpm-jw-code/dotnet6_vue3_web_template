import axios from 'axios'
var apiinstance = axios.create({
    baseURL: 'http://localhost:5185/api/Values'
})


export async function GetSystemTime() {
    var res = await apiinstance.get('SystemTime');
    return res.data;
}