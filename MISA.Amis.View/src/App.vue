<template>
  <div id="app">
    <Navbar />
    <div class="main">
      <Header />
      <EmployeeList/>
    </div>
  </div>
</template>

<script>
import Navbar from "./components/Layout/Navbar";
import Header from "./components/Layout/Header";
//import Content from "./components/Layout/Content";
import EmployeeList from './views/employee/EmployeeList.vue';

export default {
  name: "App",
  components: {
    Navbar,
    Header,
    EmployeeList,
  },
};
</script>

<style>
@import "./styles/main.css";
</style>
