<template>
  <div id="app">
    <img src="http://vuejs.org/images/logo.png">
    <hello :name-for-view="name" slot="data">Slot data</hello>
  </div>
</template>

<script>
export default {
  name: 'app',
  data () {
    return {
      name: 'GGK'
    }
  }
}
</script>

<style scoped>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

img {
  width: 200px;
  height: 200px;
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
