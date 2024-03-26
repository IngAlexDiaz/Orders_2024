using Orders.Shared.Entities;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckCoutriesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnología" });
                _context.Categories.Add(new Category { Name = "Calzados" });
                _context.Categories.Add(new Category { Name = "Deportes" });
                _context.Categories.Add(new Category { Name = "Apple" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                _context.Categories.Add(new Category { Name = "Hogar" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCoutriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new()
                {
                    Name = "Estados Unidos",
                    States =
                    [
                        new()
                        {
                            Name = "Florida",
                            Cities =
                            [
                                new() { Name = "Miami" },
                                new() { Name = "Orlando" },
                                new() { Name = "Tampa" }
                            ]
                        },

                        new()
                        {
                            Name = "California",
                            Cities =
                            [
                                new() { Name = "Los Ángeles" },
                                new() { Name = "San Francisco" },
                                new() { Name = "San Diego" }
                            ]
                        }
                    ]
                });

                _context.Countries.Add(new()
                {
                    Name = "República Dominicana",
                    States =
                    [
                        new()
                        {
                            Name = "Santo Domingo",
                            Cities =
                            [
                                new() { Name = "Santo Domingo" },
                                new() { Name = "Distrito Nacional" },
                                new() { Name = "Boca Chica" }
                            ]
                        },

                        new()
                        {
                            Name = "Puerto Plata",
                            Cities =
                            [
                                new() { Name = "Puerto Plata" },
                                new() { Name = "Sosúa" },
                                new() { Name = "Cabarete" }
                            ]
                        }
                    ]
                });

                _context.Countries.Add(new()
                {
                    Name = "Argentina",
                    States =
                    [
                        new()
                        {
                            Name = "Buenos Aires",
                            Cities =
                            [
                                new() { Name = "Buenos Aires" },
                                new() { Name = "La Plata" },
                                new() { Name = "Mar del Plata" }
                            ]
                        },

                        new()
                        {
                            Name = "Córdoba",
                            Cities =
                            [
                                new() { Name = "Córdoba" },
                                new() { Name = "Villa Carlos Paz" },
                                new() { Name = "Río Cuarto" }
                            ]
                        }
                    ]
                });

                _context.Countries.Add(new()
                {
                    Name = "Italia",
                    States =
                    [
                        new()
                        {
                            Name = "Lazio",
                            Cities =
                            [
                                new() { Name = "Roma" },
                                new() { Name = "Viterbo" },
                                new() { Name = "Frosinone" }
                            ]
                        },

                        new()
                        {
                            Name = "Lombardia",
                            Cities =
                            [
                                new() { Name = "Milán" },
                                new() { Name = "Bérgamo" },
                                new() { Name = "Brescia" }
                            ]
                        }
                    ]
                });

                _context.Countries.Add(new()
                {
                    Name = "Perú",
                    States =
                    [
                        new()
                        {
                            Name = "Lima",
                            Cities =
                            [
                                new() { Name = "Lima" },
                                new() { Name = "Miraflores" },
                                new() { Name = "San Isidro" }
                            ]
                        },

                        new()
                        {
                            Name = "Cuzco",
                            Cities =
                            [
                                new() { Name = "Cuzco" },
                                new() { Name = "Machu Picchu" },
                                new() { Name = "Ollantaytambo" }
                            ]
                        },
                    ]
                });

                _context.Countries.Add(new()
                {
                    Name = "Colombia",
                    States =
                    [
                        new()
                        {
                            Name = "Bogotá",
                            Cities =
                            [
                                new() { Name = "Bogotá" },
                                new() { Name = "Medellín" },
                                new() { Name = "Cali" }
                            ]
                        },

                        new()
                        {
                            Name = "Antioquia",
                            Cities =
                            [
                                new() { Name = "Medellín" },
                                new() { Name = "Envigado" },
                                new() { Name = "Itagüí" }
                            ]
                        },
                    ]
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}