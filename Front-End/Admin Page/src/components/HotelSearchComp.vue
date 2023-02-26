<template>
  <h1 align="left">Search your booking</h1>
  <div id="app1">
    <div class="container">
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
                  placeholder="Enter your hotel id"
                  v-model="formData.id"
                />
              </div>
              <!--end of col-->
              <div class="col-auto">
                <button class="btn btn-lg btn-success" v-on:click="fillPage">
                  Search
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
      <template v-if="formData.name">
        <table class="table table-hover">
          <tbody>
            <tr>
              <th>Hotel id</th>
              <td>{{ formData.id }}</td>
            </tr>
            <tr>
              <th>Hotel name</th>
              <td>{{ formData.hotelName }}</td>
            </tr>
            <tr>
              <th>Location</th>
              <td>{{ formData.location }}</td>
            </tr>
            <tr>
              <th>Room types</th>
              <td>{{ formData.roomTypes }}</td>
            </tr>
            <tr>
              <th>Complimentary Food</th>
              <td v-if="formData.complimentaryFood">Yes</td>
              <td v-else>No</td>
            </tr>
            <tr>
              <th>Prices</th>
              <td>{{ formData.prices }}</td>
            </tr>
          </tbody>
        </table>
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
        name: null,
        hotelName: null,
        location: null,
        roomTypes: null,
        complimentaryFood: false,
        prices: null,
      },
    };
  },

  methods: {
    async fillPage() {
      let result = await axios.get(
        "https://localhost:7225/api/Admin/" + this.formData.id
      );

      console.log(result);
      this.formData = result.data;
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
