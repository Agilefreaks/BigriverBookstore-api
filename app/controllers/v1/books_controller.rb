class V1::BooksController < ApplicationController
  def index
    books = Book.all
    render json: BookSerializer.new(books).serialized_json
  end
end