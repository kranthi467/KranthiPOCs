import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import App from '../App'
Vue.use(Router)

export default new Router({
  mode: 'history',
  base: __dirname,
  routes: [
    {
      path: '/hello',
      component: App
    },
    {
      path: '/',
      component: HelloWorld
    }
  ]
})
