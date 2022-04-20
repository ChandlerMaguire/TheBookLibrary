import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import axios from 'axios'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faMagnifyingGlass, faBookOpen, faBook, faPeopleGroup, faRightFromBracket, faRightToBracket, faBookOpenReader, faFireFlameCurved, faLeaf, faSpinner, faCirclePlus, faUserGear, faHouse,faCircleXmark, faUser, } from '@fortawesome/free-solid-svg-icons'
import { faBookmark, faCircle, faCircleCheck } from '@fortawesome/free-regular-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
library.add(faMagnifyingGlass, faBookOpen, faBookOpenReader, faBookmark, faUser, faRightFromBracket, faRightToBracket, faUserGear, faCircleXmark, faFireFlameCurved, faLeaf, faCirclePlus, faSpinner, faHouse, faBook, faPeopleGroup, faCircleCheck, faCircle)        
Vue.component('font-awesome-icon', FontAwesomeIcon)


Vue.config.productionTip = false

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
