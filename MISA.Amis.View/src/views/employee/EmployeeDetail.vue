<template>
  <div>
    <form @submit.prevent="btnSaveAddOnClick">
      <div
        id="dlgEmployeeDetail"
        class="dialog "
        :class="{ 'dialog-hide': !isShow }"
      >
        <div class="model"></div>
        <div class="dialog-content">
          <div class="dialog-header">
            <div class="dialog-title">THÔNG TIN NHÂN VIÊN</div>
            <input class="title-input" type="checkbox" /> <a>Là khách hàng</a>
            <input class="title-input" type="checkbox" /> <a>Là nhà cũng cấp</a>
            <div class="dialog-close-button" @click="btnCloseOnClick()">
              &#x2715;
            </div>
          </div>
          <div class="dialog-body">
            <div class="m-row">
              <div class="m-col">
                <label>Mã <span style="color:red">*</span></label>
                <input
                  id="txtEmployeeCode"
                  type="text"
                  :value="SetEmployeeCode"
                  autofocus
                  ref="eCode"
                  v-on:input="employee.employeeCode = $event.target.value"
                  required
                />
              </div>
              <div class="m-col">
                <label>Tên <span style="color:red">*</span></label>
                <input
                  id="txtEmployeeName"
                  type="text"
                  v-model="employee.employeeName"
                  required
                />
              </div>

              <div class="m-col">
                <label>Ngày sinh</label>
                <input
                  id="inp-dateOfBirth"
                  type="date"
                  v-bind:value="fomatDate(employee.dateOfBirth)"
                  v-on:input="employee.dateOfBirth = $event.target.value"
                />
              </div>
              <div class="m-col">
                <label>Giới tính</label>
                <div style="display:flex">
                  <div
                    class="gender-col"
                    v-for="gender in genders"
                    :key="gender.name"
                  >
                    <input
                      :value="gender.value"
                      name="gender"
                      type="radio"
                      v-model="employee.gender"
                    />
                    <span>{{ gender.name }}</span>
                  </div>
                </div>
              </div>
            </div>

            <div class="m-row">
              <div class="m-col">
                <div>
                  <label>Đơn vị <span style="color:red">*</span></label>
                  <select
                    id="cbEmployeeDepartment"
                    v-model="employee.employeeDepartmentId"
                    required
                  >
                    <option
                      v-for="department in departments"
                      :key="department.employeeDepartmentId"
                      :value="department.employeeDepartmentId"
                      >{{ department.employeeDepartmentName }}</option
                    >
                  </select>
                </div>
              </div>
              <div class="m-col" style="padding: 0">
                <div class="m-col">
                  <label>Số CMND</label>
                  <input
                    id="identifyNumber"
                    type="text"
                    v-model="employee.identificationId"
                  />
                </div>
                <div class="m-col">
                  <label>Ngày cấp</label>
                  <input
                    type="date"
                    name="identifyDate"
                    id="identifyDate"
                    v-bind:value="fomatDate(employee.identificationDate)"
                    v-on:input="
                      employee.identificationDate = $event.target.value
                    "
                  />
                </div>
              </div>
            </div>

            <div class="m-row">
              <div class="m-col">
                <label>Chức danh</label>
                <input
                  id="positionName"
                  type="text"
                  v-model="employee.employeePositionName"
                />
              </div>
              <div class="m-col">
                <label>Nơi cấp</label>
                <input
                  id="identifyPlace"
                  type="text"
                  v-model="employee.identificationPlace"
                />
              </div>
            </div>

            <div class="m-row" style="margin-top: 30px;">
              <div class="m-col" style="width: 100%;">
                <label>Địa chỉ</label>
                <input id="address" type="text" v-model="employee.address" />
              </div>
            </div>

            <div class="m-row" style="width: 80%;">
              <div class="m-col">
                <label>ĐT di động</label>
                <input
                  id="telephoneNumber"
                  type="text"
                  v-model="employee.telephoneNumber"
                />
              </div>
              <div class="m-col">
                <label>ĐT cố đinh</label>
                <input
                  id="tablephoneNumber"
                  type="text"
                  v-model="employee.tablephoneNmber"
                />
              </div>
              <div class="m-col">
                <label>Email</label>
                <input id="email" type="text" v-model="employee.email" />
              </div>
            </div>

            <div class="m-row" style="width: 80%;">
              <div class="m-col">
                <label>Tài khoản ngân hàng</label>
                <input
                  id="bankNumber"
                  type="text"
                  v-model="employee.bankNumber"
                />
              </div>
              <div class="m-col">
                <label>Tên ngân hàng</label>
                <input id="bankName" type="text" v-model="employee.bankName" />
              </div>
              <div class="m-col">
                <label>Chi nhánh</label>
                <input
                  id="bankBrach"
                  type="text"
                  v-model="employee.bankBranch"
                />
              </div>
            </div>

            <div class="dialog-footer">
              <div class="footer-left">
                <button
                  id="btnExit"
                  class="btn-default"
                  style="background-color: white; color: black; border: 1px solid black; line-height: 0; font-weight: bold"
                  @click="btnCloseOnClick()"
                >
                  Hủy
                </button>
              </div>
              <div class="footer-right">
                <button
                  id="btnSave"
                  class="btn-default"
                  style="background-color: white; color: black; border: 1px solid black; line-height: 0; font-weight: bold"
                >
                  Cất
                </button>
                <button id="btnSaveAdd" class="btn-default" type="submit">
                  Cất và thêm
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import dayjs from "dayjs";
export default {
  async created() {
    await axios
      .get("https://localhost:44355/api/v1/EmployeeDepartments")
      .then((res) => {
        this.departments = res.data;
      });
  },
  methods: {
    btnCloseOnClick() {
      this.$emit("hideDialog");
      document.getElementById("txtEmployeeCode").value = "";
    },
    fomatDate(date) {
      if (date == null) {
        return 0;
      }
      return dayjs(date).format("YYYY-MM-DD");
    },
    btnSaveAddOnClick() {
      if (this.formMode == "add") {      
        this.employee.employeeCode = this.SetEmployeeCode;    
        axios
          .post("https://localhost:44355/api/v1/Employees", this.employee)
          .then(() => {
            this.$emit("hideDialog");
          })
          .catch(() => {
            this.$emit("hideDialog");
            this.$emit("showNotice", `${this.employee.employeeCode}`);
          });
      } else if (this.formMode == "edit") {
        if (this.employee.employeeCode == null) {
          return null;
        } else {
          axios
            .put("https://localhost:44355/api/v1/Employees", this.employee)
            .then(() => {
              this.$emit("hideDialog");
            });
        }
      }
    },
  },
  props: {
    isShow: { type: Boolean, default: false },
    employee: { type: Object, default: null },
    formMode: { type: String, default: "add" },
    employeeCodeNew: { type: String, default: null },
    maxRecord: { type: Number, default: null },
  },
  data() {
    return {
      departments: [],
      genders: [
        { name: "Nam", value: 1 },
        { name: "Nữ", value: 2 },
        { name: "Khác", value: 0 },
      ],
    };
  },
  watch: {},
  computed: {
    SetEmployeeCode() {
      if (this.employee.employeeCode != null && this.maxRecord >= 0) {
        var edit = this.employee.employeeCode;
        return edit;
      } else {
        var add = "NV-" + `${this.maxRecord + 1}`;
        return add;
      }
    },
  },
};
</script>
