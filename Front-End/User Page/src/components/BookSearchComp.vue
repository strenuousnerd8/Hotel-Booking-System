<template>
  <h1 align="left">Search your booking</h1>
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
                  placeholder="Search topics or keywords"
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
      <template v-if="formData.hotelId != null">
        <table class="table table-hover">
          <tbody>
            <tr>
              <th>Booking id</th>
              <td>{{ formData.id }}</td>
            </tr>
            <tr>
              <th>Hotel id</th>
              <td>{{ formData.hotelId }}</td>
            </tr>
            <tr>
              <th>Name</th>
              <td>{{ formData.name }}</td>
            </tr>
            <tr>
              <th>Phone No</th>
              <td>{{ formData.phoneNo }}</td>
            </tr>
            <tr>
              <th>Age</th>
              <td>{{ formData.age }}</td>
            </tr>
            <tr>
              <th>Email</th>
              <td>{{ formData.email }}</td>
            </tr>
            <tr>
              <th>Aadhar / PAN No</th>
              <td>{{ formData.aadharPAN }}</td>
            </tr>
            <tr>
              <th>Room Type</th>
              <td>{{ formData.phoneNo }}</td>
            </tr>
            <tr>
              <th>Members</th>
              <td>{{ formData.members }}</td>
            </tr>
            <tr>
              <th>Check-in</th>
              <td>{{ dateParser(formData.checkin) }}</td>
            </tr>
            <tr>
              <th>Check-out</th>
              <td>{{ dateParser(formData.checkout) }}</td>
            </tr>
            <tr>
              <th>Complimentary Food</th>
              <td v-if="formData.complimentaryFood">Yes</td>
              <td v-else>No</td>
            </tr>
          </tbody>
        </table>
      </template>
      <button class="btn btn-lg btn-success" v-on:click="fetchPage">
        Get hotel details
      </button>
      <br />
      <br />
      <template v-if="fetchData.hotelName != null">
        <table class="table table-hover">
          <tbody>
            <tr>
              <th>Hotel id</th>
              <td>{{ fetchData.id }}</td>
            </tr>
            <tr>
              <th>Hotel name</th>
              <td>{{ fetchData.hotelName }}</td>
            </tr>
            <tr>
              <th>Location</th>
              <td>{{ fetchData.location }}</td>
            </tr>
            <tr>
              <th>Room types</th>
              <td>{{ fetchData.roomTypes }}</td>
            </tr>
            <tr>
              <th>Complimentary Food</th>
              <td v-if="fetchData.complimentaryFood">Yes</td>
              <td v-else>No</td>
            </tr>
            <tr>
              <th>Prices</th>
              <td>{{ fetchData.prices }}</td>
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
        hotelId: null,
        name: null,
        phoneNo: null,
        age: null,
        email: null,
        aadharPAN: null,
        roomType: null,
        members: null,
        checkin: null,
        checkout: null,
        complimentaryFood: null,
      },
      fetchData: {
        id: null,
        hotelName: null,
        location: null,
        roomTypes: null,
        complimentaryFood: false,
        prices: null,
      },
    };
  },

  methods: {
    dateParser: function parseDate(yourDate) {
      let year = yourDate.substring(0, 4);
      let month = yourDate.substring(5, 7);
      let day = yourDate.substring(8, 10);
      var nowDate = new Date(year, month, day);
      return nowDate;
    },

    async fillPage() {
      let result = await axios.get(
        "https://localhost:7239/api/Customer/" + this.formData.id
      );

      console.log(result);
      this.formData = result.data;
    },

    async fetchPage() {
      let result = await axios.get(
        "https://localhost:7225/api/Admin/Fetch/consume/"
      );

      console.log(result);
      this.fetchData = result.data;
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
