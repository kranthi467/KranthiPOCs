import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Login from '@/components/Login'

Vue.use(Router)

import auth from '../auth'

function requireAuth (to, from, next) {
  if (!auth.loggedIn()) {
    next({
      path: '',
      query: { redirect: to.fullPath }
    })
  } else {
    next()
  }
}

export default new Router({
  routes: [
    {
      path: '',
      name: 'login',
      component: Login
    },
    {
      path: 'home',
      name: 'home',
      component: Home,
      beforeEnter: requireAuth
    }
  ]
})
