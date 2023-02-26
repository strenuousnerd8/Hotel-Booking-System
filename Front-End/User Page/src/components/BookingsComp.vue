<script>
export default {
  data() {
    return {
      post: [],
    };
  },
  methods: {
    async getPosts() {
      fetch("https://localhost:7239/api/Customer")
        .then((response) => response.json())
        .then((data) => (this.post = data));
    },
    dateParser: function parseDate(yourDate) {
      let year = yourDate.substring(0, 4);
      let month = yourDate.substring(5, 7);
      let day = yourDate.substring(8, 10);
      var nowDate = new Date(year, month, day);
      var date =
        nowDate.getFullYear() +
        "/" +
        nowDate.getMonth() +
        "/" +
        nowDate.getDate();
      return date;
    },
  },
};
</script>

<template>
  <h1 align="left">Bookings</h1>
  <div id="app1" class="table-responsive">
    <button @click="getPosts">Show Bookings</button>
    <hr />
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Booking id</th>
          <th>Hotel id</th>
          <th>Name</th>
          <th>Phone No</th>
          <th>Age</th>
          <th>Email</th>
          <th>Aadhar / PAN No</th>
          <th>Room Type</th>
          <th>Members</th>
          <th>Check in</th>
          <th>Check out</th>
          <th>Complimentary food</th>
        </tr>
      </thead>
      <tbody>
        <template v-if="post.length">
          <tr v-for="p in post" :key="p.id">
            <th scope="row">{{ p.id }}</th>
            <td>{{ p.hotelId }}</td>
            <td>{{ p.name }}</td>
            <td>{{ p.phoneNo }}</td>
            <td>{{ p.age }}</td>
            <td>{{ p.email }}</td>
            <td>{{ p.aadharPAN }}</td>
            <td>{{ p.roomType }}</td>
            <td>{{ p.members }}</td>
            <td>{{ dateParser(p.checkin) }}</td>
            <td>{{ dateParser(p.checkout) }}</td>
            <td v-if="p.complimentaryFood">Yes</td>
            <td v-else>No</td>
          </tr>
        </template>
      </tbody>
    </table>
  </div>
</template>

<style>
#app1 {
  text-align: center;
  margin: 0;
  padding: 0;
}

.table {
  text-align: left;
}
</style>
