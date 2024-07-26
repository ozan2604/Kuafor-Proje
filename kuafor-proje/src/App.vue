<template>

<div>
  
  <div>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <a class="navbar-brand" href="#"><img src="https://www.kadiralkan.com.tr/wp-content/uploads/2020/12/kadiralkan-logo.png" alt="" width="300" height="93"></a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            
            <li class="nav-item">
              <router-link :to="{ path: '/about' }" class="nav-link active">Hakkımızda</router-link>
            </li>
            <li class="nav-item">
              <router-link :to="{path: '/'}" class="nav-link active">Hizmet</router-link>
            </li>
            <li class="nav-item">
              <router-link :to="{path: '/yorum'}" class="nav-link active">Yorumlar</router-link>
            </li>
            <li class="nav-item">
              <router-link :to="{path: '/rezervasyon'}" class="nav-link active">Rezervasyon</router-link>
            </li>

            <li class="nav-item">
              <router-link :to="{path : '/admin'}" class="nav-link active">Admin Girişi</router-link>
              
            </li>
            
          
          
          
          </ul>
          
        </div>
      </div>
    </nav>
    
  </div>
  <router-view />
</div>
</template>

<script>


export default {
  

};
</script>

<style>
.nav-link {
  margin-left: 100px;

}


</style>