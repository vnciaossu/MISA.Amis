<template>
  <div class="navbar">
    <div class="logo-box">
      <div class="toggle-icon"></div>
      <div class="amis-logo"></div>
    </div>
    <div class="navbar-content">
      <router-link to="/user" class="nav-item">
        <div class="ic ic-max nav-item-1"></div>
        <div class="nav-item-text">Tổng quan</div>
      </router-link>
      <div class="nav-item">
        <div class="ic ic-max nav-item-2"></div>
        <div class="nav-item-text">Tiền mặt</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-3"></div>
        <div class="nav-item-text">Tiền gửi</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-4"></div>
        <div class="nav-item-text">Mua hàng</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-5"></div>
        <div class="nav-item-text">Bán hàng</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-6"></div>
        <div class="nav-item-text">Quản lý hoá đơn</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-7"></div>
        <div class="nav-item-text">Kho</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-8"></div>
        <div class="nav-item-text">Công cụ dụng cụ</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-9"></div>
        <div class="nav-item-text">Tài sản cố định</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-10"></div>
        <div class="nav-item-text">Thuế</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-11"></div>
        <div class="nav-item-text">Giá thành</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-12"></div>
        <div class="nav-item-text">Tổng hợp</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-13"></div>
        <div class="nav-item-text">Ngân sách</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-14"></div>
        <div class="nav-item-text">Báo cáo</div>
      </div>
      <div class="nav-item">
        <div class="ic ic-max nav-item-15"></div>
        <div class="nav-item-text">Phân tích tài chính</div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "Navbar",
};
</script>

<style>
@import url("../../styles/layouts/Navbar.css");
</style>
