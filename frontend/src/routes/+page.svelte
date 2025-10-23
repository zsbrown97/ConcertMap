<script lang="ts">
    import Map from "$lib/components/Map.svelte";
</script>


<div class="p-6 space-y-4">

    <h1 class="text-3xl font-bold underline">Welcome to SvelteKit</h1>
    <Map />
</div>

<style lang="postcss">
    @reference "tailwindcss";

    :global(html) {
        background-color: theme(--color-gray-100);
    }
</style>