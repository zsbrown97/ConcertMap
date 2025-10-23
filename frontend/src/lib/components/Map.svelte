<script lang="ts">
  import { onMount } from 'svelte';

  let mapContainer: HTMLDivElement;

  onMount(async () => {
    const L = await import('leaflet'); 

    const map = L.map(mapContainer).setView([37.7749, -122.4194], 3);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors'
    }).addTo(map);

    L.marker([37.7749, -122.4194])
      .addTo(map)
      .bindPopup('Hello from SvelteKit + Leaflet!')
      .openPopup();

  });
</script>

<div
  bind:this={mapContainer}
  class="h-[400px] w-full rounded-2xl shadow-md border border-gray-300"
></div>
