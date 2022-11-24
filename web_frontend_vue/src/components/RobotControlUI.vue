<template>
  <div class="robot-control">
    <div class="settings">
      <div class="topics">
        <span>Topic</span>
        <div>
          <div class="topic">
            <span>move</span>
            <div class="topic-input">
              <el-input v-model="topics.move" size="small"></el-input>
            </div>
            <el-button @click="SetMoveTopic()" size="small">Set</el-button>
          </div>
          <div class="topic">
            <span>fork控制</span>
            <div class="topic-input">
              <el-input v-model="topics.fork" size="small"></el-input>
            </div>
            <el-button @click="SetForkTopic()" size="small">Set</el-button>
          </div>
        </div>
      </div>
      <div>
        <span>速度</span>
        <el-input-number size="small" v-model="speed"></el-input-number>
      </div>
      <div>
        <span>角度</span>
        <el-input-number size="small" v-model="angle"></el-input-number>
      </div>
    </div>
    <el-divider></el-divider>
    <div class="controls">
      <div class="robot-move">
        <h4>Robot移動</h4>
        <div>
          <button @click="MoveInvoke('forward',speed)">Up</button>
        </div>
        <div>
          <button @click="MoveInvoke('left',-1*angle)">Left</button>
          <button @click="MoveInvoke('stop',-1)">Stop</button>
          <button @click="MoveInvoke('right',angle)">Right</button>
        </div>
        <div>
          <button @click="MoveInvoke('backward',-1*speed)">Down</button>
        </div>
      </div>
      <div class="fork-control">
        <h4>Fork控制</h4>
        <div>
          <button @click="ForkInvoke('forward')">前</button>
          <button @click="ForkInvoke('backward')">後</button>
        </div>
        <div>
          <button @click="ForkInvoke('up')">上</button>
          <button @click="ForkInvoke('down')">下</button>
        </div>
        <div>
          <button @click="ForkInvoke('incline-forward')">前傾</button>
          <button @click="ForkInvoke('incline-backward')">後傾</button>
        </div>
      </div>
    </div>
    <el-divider></el-divider>
    <div class="server-reply">{{server_reply_dat}}</div>
  </div>
</template>

<script>
import { Move, Fork, SetForkControlTopic, SetMoveTopic, GetForkControlTopic, GetMoveTopic } from "@/WebAPI/RobotAPI"
export default {
  data() {
    return {
      server_reply_dat: '',
      topics: {
        move: "",
        fork: ""
      },
      speed: 1,
      angle: 30,

    }
  },
  methods: {
    async MoveInvoke(direction, value) {
      this.server_reply_dat = 'MOVE:' + await Move(direction, value);
    },
    async ForkInvoke(action) {
      this.server_reply_dat = 'FORK:' + await Fork(action);

    },
    async SetMoveTopic() {
      await SetMoveTopic(this.topics.move);
    },
    async SetForkTopic() {
      await SetForkControlTopic(this.topics.fork);
    }
  },
  mounted() {
    GetMoveTopic().then(topic => this.topics.move = topic);
    GetForkControlTopic().then(topic => this.topics.fork = topic);
  }
}
</script>

<style lang="scss" scoped>
.robot-control {
  border: 1px solid black;
  margin: 10px;
  span {
    margin: auto 10px;
  }
  .settings {
    padding-top: 20px;
    padding-left: 10px;
    div {
      display: flex;
    }
    .topic {
      display: flex;
    }
    .topic-input {
      width: 200px;
    }
  }
  .controls {
    display: flex;
    flex-flow: row;
    justify-content: center;
    background-color: rgb(131, 158, 175);
    button {
      padding: 10px;
      width: 60px;
      height: 60px;
    }
    button:active {
      background-color: red;
      color: white;
    }
    .robot-move,
    .fork-control {
      padding: 8px;
      margin-inline: 20px;
    }
  }
  .server-reply {
    background-color: rgb(92, 92, 92);
    color: white;
    height: 40px;
    margin: 10px;
  }
}
</style>