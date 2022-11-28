<template>
  <div class="my-nav w-100 px-2">
    <div class="flex-fill">
      <nav class="navbar navbar-expand-sm navbar-light bg-light">
        <a class="navbar-brand" href="#">ROS</a>
        <button
          class="navbar-toggler d-lg-none"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#collapsibleNavId"
          aria-controls="collapsibleNavId"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span>
            <i class="bi bi-list"></i>
          </span>
        </button>
        <div class="collapse navbar-collapse" id="collapsibleNavId">
          <ul class="navbar-nav me-auto mt-2 mt-lg-0">
            <li class="nav-item">
              <a class="nav-link active" href="#" aria-current="page">
                Home
                <span class="visually-hidden">(current)</span>
              </a>
            </li>
            <!-- <li class="nav-item">
              <a class="nav-link" href="#">Link</a>
            </li>
            <li class="nav-item dropdown">
              <a
                class="nav-link dropdown-toggle"
                href="#"
                id="dropdownId"
                data-bs-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >Dropdown</a>
              <div class="dropdown-menu" aria-labelledby="dropdownId">
                <a class="dropdown-item" href="#">Action 1</a>
                <a class="dropdown-item" href="#">Action 2</a>
              </div>
            </li>-->
          </ul>
          <!-- <form class="d-flex my-2 my-lg-0">
            <input class="form-control me-sm-2" type="text" placeholder="Search" />
            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
          </form>-->
        </div>
      </nav>
    </div>
    <div class="connections border">
      <div>
        <span>Server</span>
        <el-tag effect="dark" type="danger">Disconnect</el-tag>
      </div>
      <div>
        <span>ROS</span>
        <el-tag effect="dark" type="danger">Disconnect</el-tag>
      </div>
    </div>
  </div>
</template>




<script>
export default {
  mounted() {

  }
}
</script>

<style lang="scss" scoped>
.my-nav {
  display: flex;
  justify-content: space-between;
}
.connections {
  background-color: rgb(232, 233, 233);
  padding-top: 10px;
  padding-right: 10px;
  display: flex;

  div {
    margin: 0 10px;
    span {
      padding: 2px 5px;
    }
  }
}
@media screen and (max-width: 600px) {
  .my-nav {
    // background-color: red;
    display: block;
  }
  .connections {
    position: absolute;
    top: 13px;
    right: 63px;
    padding: 0;
  }
}
</style>