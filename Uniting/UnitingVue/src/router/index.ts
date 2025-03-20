import { createRouter, createWebHistory, useRouter } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { useAuthStore } from '@/stores/auth'

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
      name: 'blogs',
      meta: {requiresAuth: true}
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
        {
          path: 'profile',
          component: ()=>import('../views/ProfileView.vue'),
          name: 'profile',
          meta: {requiresAuth: true}
        }
      ],
    },
  ],
})



router.beforeEach((to, from, next)=>{

  const store = useAuthStore();
  const storage = localStorage.getItem("userData");
  const router = useRouter();

  if(to.meta.requiresAuth  && !store.isLoggedIn){
    next({name: 'login'})
  }else next();

})



export default router
