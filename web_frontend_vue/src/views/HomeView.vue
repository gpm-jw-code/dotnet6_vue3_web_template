<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <HelloWorld msg="Welcome to Your Vue.js App" />
    <HelloVueVue></HelloVueVue>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import HelloVueVue from '@/components/HelloVue.vue';
export default {
  name: 'HomeView',
  components: {
    HelloWorld, HelloVueVue
  }
}
</script>
