import axios from 'axios'
var apiinstance = axios.create({
  baseURL: 'http://localhost:5185/api/ForkRobot',
})

apiinstance.interceptors.request.use(
  (config) => {
    return config
  },
  (err) => {
    $Toast.Error(err.toString())
    return Promise.reject(err)
  },
)

apiinstance.interceptors.response.use(
  (res) => {
    return res
  },
  (err) => {
    $Toast.Error(err.toString(), 3, 'top-right')
    // alert('request error', err.toString())
    return Promise.reject(err)
  },
)

export async function SetRobotMoveTopic(topic) {}

export async function Move(direction, value) {
  var response = await apiinstance
    .get(`/Move?direction=${direction}&value=${value}`)
    .catch((er) => alert(er))
  return response.data
}

export async function Fork(action) {
  var response = await apiinstance
    .get(`/Fork?action=${action}`)
    .catch((er) => alert(er))
  return response.data
}
export async function GetMoveTopic() {
  var response = await apiinstance.get(`/MoveTopic`)
  return response.data
}
export async function SetMoveTopic(topic) {
  var response = await apiinstance.post(`/MoveTopic?topic=${topic}`)
  return response.data
}
export async function GetForkControlTopic() {
  var response = await apiinstance.get(`/ForkControlTopic`)
  return response.data
}

export async function SetForkControlTopic(topic) {
  var response = await apiinstance.post(`/ForkControlTopic?topic=${topic}`)
  return response.data
}
