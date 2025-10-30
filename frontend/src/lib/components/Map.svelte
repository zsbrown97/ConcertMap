<script lang="ts">
    import { onMount } from 'svelte';
    import { getAllVenues } from '$lib/api/venues';

    let mapContainer: HTMLDivElement;

    let venues: any[] = [];

    onMount(async () => {
        const [venueData] = await Promise.all([
            getAllVenues(fetch)
        ]);
        venues = venueData;
   
        const L = await import('leaflet');
        const map = L.map(mapContainer);

        let bounds = L.latLngBounds([])

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors'
        }).addTo(map);

        venues.forEach((v) => {
            L.marker([v.latitude, v.longitude])
                .bindPopup(v.name)
                .addTo(map);
            bounds.extend([v.latitude, v.longitude])
        })

        map.fitBounds(bounds)
    });

</script>

<div bind:this={mapContainer}
    class="
        border
        border-gray-300
        h-[50vh]
        rounded-2xl
        shadow-md
        w-full 
    "
>
</div>