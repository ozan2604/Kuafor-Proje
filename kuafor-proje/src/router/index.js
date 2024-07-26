import { createRouter, createWebHistory } from 'vue-router'
import AdminView from '../views/AdminView.vue'
import AboutView from '../views/AboutView.vue'
import HizmetView from '../views/HizmetView.vue'
import YorumView from '../views/YorumView.vue'
import RezervasyonView from '../views/RezervasyonView.vue'
import AdminBilgiView from '../views/AdminBilgiView.vue'

const routes = [
  {
    path: '/admin',
    name: 'admin',
    component: AdminView
  },
  {
    path: '/about',
    name: 'about',
    component: AboutView
  },
  {
    path: '/',
    name: 'hizmet',
    component: HizmetView

  },
  {
    path: '/yorum',
    name: 'yorum',
    component: YorumView
  },

  {
    path: '/rezervasyon',
    name: 'rezervasyon',
    component: RezervasyonView
  },
  {
    path: '/adminbilgi',
    name: 'adminbilgi',
    component: AdminBilgiView
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
