import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import axios from 'axios'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faBookmark, faBookOpen, faBook, faPeopleGroup, faRightFromBracket, faRightToBracket, faBookOpenReader, faCirclePlus, faFireFlameCurved, faLeaf, faSpinner, faUser, faUserGear, faHouse } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
library.add(faBookOpen, faBookOpenReader, faBookmark, faUser, faRightFromBracket, faRightToBracket, faUserGear, faFireFlameCurved, faLeaf, faCirclePlus, faSpinner, faHouse, faBook, faPeopleGroup)        
Vue.component('font-awesome-icon', FontAwesomeIcon)


Vue.config.productionTip = false

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
