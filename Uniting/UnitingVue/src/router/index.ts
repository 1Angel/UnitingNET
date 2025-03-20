import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/explore',
      component: () => import('../views/ExploreView.vue'),
      name: 'explore',
    },
    {
      path: '/blogs',
      component: ()=> import('../views/BlogView.vue'),
      name: 'blogs'
    },
    {
      path: '/community/:id',
      component: () => import('../views/CommunityDetailsView.vue'),
      name: 'communityDetails',
    },
    {
      path: '/auth',
      children: [
        {
          path: 'login',
          component: () => import('../views/LoginView.vue'),
          name: 'login',
        },
        {
          path: 'register',
          component: () => import('../views/RegisterView.vue'),
          name: 'register',
        },
      ],
    },
  ],
})

export default router
