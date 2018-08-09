<template>
  <div id="default">
    <p>
      <router-link to="{ name: 'hello', params: {placeName: 'Hi' } }">home</router-link>
    </p>
    
    <img src="./assets/logo.png">
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'Apper'
}
</script>

<style>
#default {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
