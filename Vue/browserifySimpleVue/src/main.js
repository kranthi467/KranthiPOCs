import Vue from 'vue'
import App from './App.vue'
import Hello from './components/Hello.vue'



new Vue({
  el: '#app',
  components: {Hello},
  render: h => h(App)
})
