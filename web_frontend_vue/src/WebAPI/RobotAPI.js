import axios from 'axios'
var apiinstance = axios.create({
  baseURL: 'http://localhost:5185/api/ForkRobot',
})

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
