import Vue from 'vue'
import Router from 'vue-router'
import auth from '@/auth'
import About from '@/components/About'
import Dashboard from '@/components/Dashboard'
import Login from '@/components/Login'

Vue.use(Router)
function requireAuth (to, from, next) {
  if (!auth.loggedIn()) {
    next({
      path: '/login',
      query: { redirect: to.fullPath }
    })
  } else {
    next()
  }
}

export default new Router({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/about', component: About },
    { path: '/dashboard', component: Dashboard, beforeEnter: requireAuth },
    { path: '/login', component: Login },
    { path: '/logout',
      beforeEnter (to, from, next) {
        auth.logout()
        next('/')
      }
    }
  ]
})
