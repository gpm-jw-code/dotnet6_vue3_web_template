<template>
  <div class="hello-vue">
    <button @click="GetSysTime()">Get Sys Time</button>
  </div>
</template>

<script>
import { GetSystemTime } from '@/WebAPI/Values';
export default {
  methods: {
    async GetSysTime() {
      var time = await GetSystemTime();
      alert(time);
    }
  },
}
</script>

<style lang="scss" scoped>
</style>