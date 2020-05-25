class Book < ApplicationRecord
  has_many :book_genres
  has_many :genres, through: :book_genres

  scope :by_genre_ids, -> genre_ids { joins(book_genres: :genre).where({ genres: { id: genre_ids.split(',') } }) }
end