import pygame


#Initialize the pygame
pygame.init()

running = True
screen = pygame.display.set_mode((800, 600))

while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

