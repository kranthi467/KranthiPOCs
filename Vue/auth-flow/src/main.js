import Vue from 'vue'
import VueRouter from 'vue-router'
import router from './router'
import App from './App'

Vue.use(VueRouter)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  // replace the content of <div id="app"></div> with App
  render: h => h(App)
})
