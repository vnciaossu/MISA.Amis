<template>
  <div id="content">
      <CustomerList/>
  </div>
</template>
<script>
import CustomerList from '../../views/customer/CustomerList.vue';
  export default{
    component:{
      CustomerList
  }
}
</script>
<style>
@import url("../../styles/layouts/Content.css");
</style>
