<template>
  <div>
    <div :class="{ 'dialog-hide': !isShowExits }">
      <div class="model"></div>
      <div class="notice-dialog">
        <div class="main-notice-dialog">
          <div class="header-notice">
            <div class="dialog-notice--icon ic ic-36 notice-icon"></div>
            <div class="messeger-notice">
              Mã nhân viên <span>&lt;{{ employeeCode }}&gt; </span>đã tồn tại
              trong hệ thống, vui lòng kiếm tra lại.
            </div>
          </div>
          <div class="footer-notice">
            <button
              class="btn-default btn-notice-access"
              @click="btnHideNotice()"
            >
              Đồng ý
            </button>
          </div>
        </div>
      </div>
    </div>

    <div :class="{ 'dialog-hide': !isShowDelete }">
      <div class="model"></div>
      <div class="notice-dialog">
        <div class="main-notice-dialog">
          <div class="header-notice">
            <div class="dialog-notice--icon ic ic-36 notice-icon"></div>
            <div class="messeger-notice">
              Bạn có thực sự muốn xóa Nhân viên
              <span>&lt;{{ employeeCode }}&gt; </span> không?
            </div>
          </div>
          <div class="footer-notice">
            <div class="btn-delete-no btn-default " @click="btnHideNotice()">
              Không
            </div>
            <div class="btn-default btn-delete-yes" @click="btnDelete()">
              Có
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {},
  methods: {
    btnHideNotice() {
      this.$emit("hideNotice");
    },
    btnDelete() {
      this.$emit("hideNotice");
    },
  },
  props: {
    isShowExits: { type: Boolean, default: false },
    isShowDelete: { type: Boolean, default: false },
    employeeCode: { type: String, default: null },
    employeeClick: { type: String, default: null },
  },
};
</script>

<style>
@import url("../../styles/views/dialogs/NoticeDialog.css");

.dialog-hide {
  display: none;
}
</style>
