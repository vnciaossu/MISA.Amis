<template>
  <div>
    <div id="EmployeeList">
      <div class="icon-loader" v-show="isLoading"></div>
      <div class="list-header">
        <div class="list-header-left">Nhân viên</div>
        <div class="list-header-right">
          <div class="btn-default" @click="btnAddOnClick()">
            Thêm mới nhân viên
          </div>
        </div>
      </div>
      <div class="backgroud-table">
        <div class="table-kit">
          <div class="kit">
            <div class="kit-filter">
              <input
                v-model="filters"
                @input="filterRecord(1)"
                class="filter-input"
                placeholder="Tìm theo mã, tên nhân viên"
              />
              <div class="ic ic-max find-icon"></div>
            </div>
            <div
              class="btn-reload ic ic-max reload-icon"
              @click="loadData()"
            ></div>
            <div
              class="btn-excel ic ic-max excel-icon"
              @click="tableToExcel('table', 'test')"
            ></div>
          </div>
        </div>
        <div class="list-table">
          <table
            ref="table"
            id="tblListEmployee"
            class="table"
            width="100%"
            border="0"
          >
            <thead>
              <tr>
                <th><input class="tb-checkbox" type="checkbox" /></th>
                <th>MÃ NHÂN VIÊN</th>
                <th>TÊN NHÂN VIÊN</th>
                <th>GIỚI TÍNH</th>
                <th>NGÀY SINH</th>
                <th>SỐ CMND</th>
                <th>CHỨC DANH</th>
                <th>TÊN ĐƠN VỊ</th>
                <th>SỐ TÀI KHOẢN</th>
                <th>TÊN NGÂN HÀNG</th>
                <th>CHI NHÁNH TK NGÂN HÀNG</th>
                <th>CHỨC NĂNG</th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="employee in employees"
                :key="employee.employeeId"
                @click="
                  GetEmployeeIdClick(employee.employeeId, employee.employeeCode)
                "
                @dblclick="ShowEmployeeDetail(employee.employeeId)"
                v-bind:class="{
                  employeeClick: employee.employeeId === employeeClick,
                }"
              >
                <th><input class="tb-checkbox" type="checkbox" /></th>
                <th>{{ employee.employeeCode }}</th>
                <th>{{ employee.employeeName }}</th>
                <th>{{ employee.genderName }}</th>
                <th>{{ fomatBirthday(employee.dateOfBirth) }}</th>
                <th>{{ employee.identificationId }}</th>
                <th>{{ employee.employeePositionName }}</th>
                <th>{{ employee.employeeDepartmentName }}</th>
                <th>{{ employee.bankNumber }}</th>
                <th>{{ employee.bankName }}</th>
                <th>{{ employee.bankBranch }}</th>
                <th>
                  <div style="display:flex">
                    <span
                      style="color:#0374d6"
                      @click="ShowEmployeeDetail(employee.employeeId)"
                      >Sửa</span
                    >
                    <select
                      class="function-select"
                      style="margin: -1px 0 0 5px;"
                      v-model="functionIndex"
                      @change="functionFillter(functionIndex)"
                    >
                      <option
                        v-for="f in functions"
                        :key="f.name"
                        :value="f.value"
                        >{{ f.name }}</option
                      >
                    </select>
                  </div>
                </th>
              </tr>
            </tbody>
          </table>
        </div>

        <div class="list-footer" style="border-top: 1px solid #bebebe">
          <dir class="list-footer-left">
            <div class="footer-text">
              Tổng số:
              <span style="font-weight: bold">{{ totalRecord }} </span> bản ghi
            </div>
          </dir>
          <dir class="list-footer-right">
            <div class="footer-select-pagesize">
              <select
                id="pageSize"
                v-model="pageSizeSelected"
                @change="loadData()"
              >
                <option
                  v-for="pageSize in pageSizes"
                  :key="pageSize.name"
                  :value="pageSize.value"
                  >{{ pageSize.name }}
                </option>
              </select>
            </div>
            <div class="footer-select-page">
              <div
                class="select-page-prev"
                :class="{'disabledbutton':! (page > 1)}"
                @click="filterRecord((page = page - 1))"
              >
                Trước
              </div>
              <button
                class="button-custom select-page-number"
                v-for="p in pages"
                :key="p"
                @click="filterRecord(p)"
                :class="{ 'btn-pagenumber-selected': p == page }"
              >
                {{ p }}
              </button>
              <div
                class="select-page-next"              
                :class="{'disabledbutton':! (page < totalPages)}"
                @click="filterRecord((page = page + 1))"
              >
                Sau
              </div>
            </div>
          </dir>
        </div>
      </div>
    </div>

    <EmployeeDetail
      :isShow="isShow"
      @hideDialog="HideEmployeeDetail()"
      :employee="employeeDetail"
      :formMode="dialogFormMode"
      @showNotice="ShowNotice"
      :maxRecord="totalRecord"
    />

    <NoticeDialog
      :isShowExits="isShowExits"
      :isShowDelete="isShowDelete"
      @hideNotice="HideNotice"
      :employeeCode="isEmployeeCode"
      :employeeClick="employeeClick"
    />
  </div>
</template>

<script>
import axios from "axios";
import dayjs from "dayjs";

//import components
import EmployeeDetail from "./EmployeeDetail.vue";
import NoticeDialog from "../dialog/NoticeDialog.vue";
export default {
  components: {
    EmployeeDetail,
    NoticeDialog,
  },
  created() {
    this.isLoading = true;
    this.loadData();
  },
  methods: {
    loadTotalRecord() {
      axios
        .get("https://localhost:44355/api/v1/Employees/total")
        .then((res) => {
          this.totalRecord = res.data;
        });
    },

    loadData() {
      axios
        .get(
          `https://localhost:44355/api/v1/Employees/pagging?pageIndex=1&pageSize=${this.pageSizeSelected}`
        )
        .then((res) => {
          this.page = 1;
          this.totalPages = 3;
          this.employees = res.data;
          this.loadTotalRecord();
          this.isLoading = false;
        });
    },
    fomatBirthday(cusbirthday) {
      if (cusbirthday == null) {
        return "Không có";
      }
      return dayjs(cusbirthday).format("DD/MM/YYYY");
    },
    GetEmployeeIdClick(employeeId, employeeCode) {
      this.employeeClick = employeeId;
      this.isEmployeeCode = employeeCode;
    },
    ShowEmployeeDetail(employeeId) {
      axios
        .get("https://localhost:44355/api/v1/Employees/" + employeeId)
        .then((res) => {
          this.employeeDetail = res.data;
          this.isShow = true;
          this.dialogFormMode = "edit";
        });
    },
    btnAddOnClick() {
      this.isShow = true;
      this.dialogFormMode = "add";
      this.employeeDetail = {};
    },
    HideEmployeeDetail() {
      this.isShow = false;
      this.loadData();
    },
    filterRecord(pageIndex) {

      clearTimeout(this.timeOut);
      this.timeOut = setTimeout(() => {
              this.isLoading = true;
        axios
          .get(
            `https://localhost:44355/api/v1/Employees/pagging?pageIndex=${pageIndex}&pageSize=${this.pageSizeSelected}&fillter=${this.filters}`
          )
          .then((res) => {
            this.employees = res.data;
            this.page = pageIndex;
            if (res.data.length >= this.pageSizeSelected) {
              this.totalPages = pageIndex + 1;
            } else {
              this.totalPages = pageIndex;
            }
            this.isLoading = false;
          });
      }, 500);
    },
    functionFillter(functionCode) {
      if (functionCode == 1) {
        this.isShowDelete = true;
      }

      this.functionIndex = null;
    },
    functionDelete() {
      axios
        .delete(
          `https://localhost:44355/api/v1/Employees?employeeId=${this.employeeClick}`
        )
        .then(() => {
          this.loadData();
          this.page = 1;
          this.totalPages = 3;
        });
    },
    ShowNotice(employeeCode) {
      this.isShowExits = true;
      this.isEmployeeCode = employeeCode;
    },
    HideNotice(hide) {
      this.isShowExits = false;
      this.isShowDelete = false;
      if(hide != "hide"){
         this.functionDelete();
      }
     
    },
    tableToExcel(table, name) {
      console.log(table.innerHTML);
      if (!table.nodeType) table = this.$refs.table;
      var ctx = { worksheet: name || "Worksheet", table: table.innerHTML };
      window.location.href =
        this.uri + this.base64(this.format(this.template, ctx));
    },
  },
  props: [],
  data() {
    return {
      dialogFormMode: "add",
      employees: [],
      employeeClick: null,
      employeeDetail: {},
      isShow: false,
      totalRecord: 0,
      timeOut: null,
      pageSizeSelected: "20",
      pageSizes: [
        { name: "10 bản ghi trên 1 trang", value: 10 },
        { name: "20 bản ghi trên 1 trang", value: 20 },
        { name: "30 bản ghi trên 1 trang", value: 30 },
        { name: "40 bản ghi trên 1 trang", value: 40 },
        { name: "50 bản ghi trên 1 trang", value: 50 },
      ],
      page: 1,
      totalPages: 3,
      filters: "",
      functionIndex: null,
      functions: [
        { name: "Nhân bản", value: 2 },
        { name: "Xóa", value: 1 },
        { name: "Ngưng sử dụng", value: 0 },
      ],
      isShowExits: false,
      isShowDelete: false,
      isEmployeeCode: null,
      uri: "data:application/vnd.ms-excel;base64,",
      template:
        '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>',
      base64: function(s) {
        return window.btoa(unescape(encodeURIComponent(s)));
      },
      format: function(s, c) {
        return s.replace(/{(\w+)}/g, function(m, p) {
          return c[p];
        });
      },
      isLoading: false,
    };
  },
  computed: {
    pages() {
      var pageArray = [];
      var start = this.page >= 3 ? this.page - 1 : 1;
      var end =
        this.page < this.totalPage - 2 ? this.page + 1 : this.totalPages;
      for (let i = start; i <= end; i++) {
        pageArray.push(i);
      }
      return pageArray;
    },
  },
};
</script>
<style>
@import url("../../styles/views/employeeList.css");

.employeeClick {
  background-color: #bbb;
}
.btn-pagenumber-selected {
  border: 1px solid black;
}

.disabledbutton {
    pointer-events: none;
    opacity: 0.4;
}

.icon-loader{
    z-index: 10000;
    top:50%;
    left: 50%;
    position: fixed;
    justify-content: center;
    align-items: center;
    background: url("../../assets/img/Sprites.svg") no-repeat;
    background-position: -1597px -882px;
    height: 54px;
    width: 54px;
    transform: rotate(45deg 16deg 16deg);
    -webkit-animation: spin 1s linear infinite;
    animation: spin 1s linear infinite;

}
  @-webkit-keyframes spin {
    0% { -webkit-transform: rotate(0deg); }
    100% { -webkit-transform: rotate(360deg); }
  }
  
  @keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
  }
</style>
