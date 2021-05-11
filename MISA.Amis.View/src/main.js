import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";

//import compoments
import EmployeeList from "./views/employee/EmployeeList.vue";

const routers = [{ path: "/user", component: EmployeeList }];

const router = new VueRouter({
  routers,
});
Vue.config.productionTip = false;
Vue.use(VueRouter);
new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
