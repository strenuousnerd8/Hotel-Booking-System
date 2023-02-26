<template>
  <h1 align="left">Cancel your booking</h1>
  <div id="app1">
    <div class="container">
      <br />
      <div class="row justify-content-center">
        <div class="col-12 col-md-10 col-lg-8">
          <div class="card card-sm">
            <div class="card-body row no-gutters align-items-center">
              <div class="col-auto">
                <i class="fas fa-search h4 text-body"></i>
              </div>
              <!--end of col-->
              <div class="col">
                <input
                  class="form-control form-control-lg form-control-borderless"
                  type="search"
                  placeholder="Enter your booking id"
                  v-model="formData.id"
                />
              </div>
              <!--end of col-->
              <div class="col-auto">
                <button class="btn btn-lg btn-success" v-on:click="canBook">
                  Cancel
                </button>
              </div>
              <!--end of col-->
            </div>
          </div>
        </div>
        <!--end of col-->
      </div>
    </div>
    <br />
    <div class="table-responsive">
      <template v-if="formData.resp != null">
        <h3>Thank You!</h3>
        <p style="font-size: 3vh">
          Your booking id:
          <i>
            <b>{{ formData.id }}</b>
          </i>
          is cancelled!
        </p>
      </template>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      formData: {
        id: null,
        resp: null,
      },
    };
  },

  methods: {
    async canBook() {
      let result = await axios.delete(
        "https://localhost:7239/api/Customer/" + this.formData.id
      );

      console.log(result);
      if (result.status == 200) {
        this.formData.resp = true;
      }
    },
  },
};
</script>

<style>
.form-control-borderless {
  border: none;
}

.form-control-borderless:hover,
.form-control-borderless:active,
.form-control-borderless:focus {
  border: none;
  outline: none;
  box-shadow: none;
}
</style>
